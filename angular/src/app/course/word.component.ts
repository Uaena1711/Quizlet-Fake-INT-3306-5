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
  cardname: '';
  cardvn: '';
  cardid: number;
  cardWords: Array<any>;
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
      this.cardWords = data;
      this.cardname = this.cardWords[0].name;
      this.cardvn = this.cardWords[0].vn;
      this.cardid = 0;
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
  public next(){
    if (this.cardid < this.cardWords.length-1){
      this.cardid += 1;
      this.cardname = this.cardWords[this.cardid].name;
      this.cardvn = this.cardWords[this.cardid].vn;
    } else {
      this.cardid = 0;
      this.cardname = this.cardWords[this.cardid].name;
      this.cardvn = this.cardWords[this.cardid].vn;
    }
  }
  public prev(){
    if (this.cardid > 0){
      this.cardid -= 1;
      this.cardname = this.cardWords[this.cardid].name;
      this.cardvn = this.cardWords[this.cardid].vn;
    } else {
      this.cardid = this.cardWords.length -1;
      this.cardname = this.cardWords[this.cardid].name;
      this.cardvn = this.cardWords[this.cardid].vn;
    }
  }
  public flip(id){
    var cardtu = document.querySelector('#'+id);
    cardtu.classList.toggle('is-flipped');
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
  }
}
