import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ServerHttpService } from '../WordService/server-http.service';
import { ServerHttpService as LessonServe } from '../LessionService/server-http.service';

@Component({
  selector: 'app-word',
  templateUrl: './word.component.html',
  styleUrls: ['./word.component.scss']
})
export class WordComponent implements OnInit {
  form: FormGroup;
  addMode = true;
  nameLession: '';
  id: '';
  name: '';
  vn: '';
  en: '';
  words: [];
  isOwner: boolean;
  constructor(private fb: FormBuilder,
    private Service: ServerHttpService,
    private route: ActivatedRoute,
    private lessonSer: LessonServe
  ) { }

  ngOnInit(): void {
    this.Service.idLession = this.route.snapshot.params.idLession;
    this.isOnwer();
    this.nameLession = this.route.snapshot.params.nameLession;
    this.Service.getWordOfLession(this.Service.idLession).subscribe((data => {
      this.words = data;
    }));
    this.form = this.fb.group({
      name: this.name,
      vn: this.vn,
      en: this.en
    }
    );
  }
  public isOnwer() {
      this.lessonSer.isOwner(this.Service.idLession).subscribe(
        (
          data => {
            this.isOwner = data;
          }
        )
      );
  }
  public Save() {
    if (this.addMode === true) {
      this.Service.addWord(
        {
          "name": this.form.controls.name.value,
          "vn": this.form.controls.vn.value,
          "en": this.form.controls.en.value,
          "lessonId": this.Service.idLession
        }
      ).subscribe((data => {
        location.reload();
      }))
    } else {
      this.Service.editWord({
        "name": this.form.controls.name.value,
        "vn": this.form.controls.vn.value,
        "en": this.form.controls.en.value,
        "lessonId": this.Service.idLession
      }, this.id).subscribe((data => {
        this.addMode = true;
        this.id = '';
        this.name = '';
        this.vn = '';
        this.en = '';
        location.reload();
      }));
    }
  }
  public Cancel() {
    location.reload();
  }
  public Delete(id) {
    this.Service.deleteWord(id).subscribe((data => {
      location.reload();
    }))
  }
  public Edit(id, name, vn, en) {
    this.addMode = false;
    this.name = name;
    this.vn = vn;
    this.en = en;
    this.id = id;
    this.form = this.fb.group({
      name: this.name,
      vn: this.vn,
      en: this.en
    });
    window.scrollTo(0, 0);
  }
}
