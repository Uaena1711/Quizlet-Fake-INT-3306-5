import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { LearnDto, LearnService } from '@proxy/learns';
import { Word, WordDto, WordService } from '@proxy/words';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss']
})
export class TestComponent implements OnInit {
  idcourse : any;
  test : Array<testx> = new Array();
  words: Array<LearnDto> = new Array();
  currnumber : number  ;
  conlai : number ;
   alphas:string[];
   sai: number = 0;
   diem: string = ""; 
   showans: boolean = false;

  constructor( private route: ActivatedRoute,
    private lessonService: LearnService) { }
    
  ngOnInit(): void {
    this.idcourse =  this.route.snapshot.params.idcourse;
    this.lessonService.getMyReviewByIdcourse(this.idcourse).
    subscribe((data => {
    this.words = data;
    this.alphas = ["1","2","3","4"] ;
     this.generateQuestion();
     console.log(this.test);
    }));
  }
  generateQuestion()
  {
    var len = this.words.length;
    
   
   
    
    this.words.forEach((value , index) => {
      
      
     let tmp = this.words.slice();
     tmp[index] = tmp[tmp.length -1]
      console.log('t', tmp);
      let tmpindex : number = 0;
      
    
      tmpindex = this.randomIntFromInterval(0,tmp.length-2);
      let w1 = tmp[tmpindex];
      tmp[tmpindex] = tmp[tmp.length - 2];
      
      
      tmpindex = this.randomIntFromInterval(0,tmp.length-3);
      let w2 = tmp[tmpindex];
      tmp[tmpindex] = tmp[tmp.length - 3];
      
      tmpindex = this.randomIntFromInterval(0,tmp.length-4);
      let w3 = tmp[tmpindex];
      tmp[tmpindex] = tmp[tmp.length - 4];
      
      tmpindex = this.randomIntFromInterval(0,tmp.length-5);
      let w4 = tmp[tmpindex];
      tmp[tmpindex] = tmp[tmp.length - 5];
      
      var object = {
        arr: [{
          word: w1, ans: false

        },{
          word: w2, ans: false
        },{
          word: w3, ans: false
        },{
          word: w4, ans: false
        }],
        ans: value,
        tf: false
      };
      var x = this.randomIntFromInterval(0,3);
      object.arr[x].ans = true;
      object.arr[x].word = value;
      //console.log('ob',object);
      this.test.push(object);
     
    });

    //this.currentes = this.test[0];
    //console.log('curren ', this.currentes);
    //console.log('test',this.test);
    //console.log('ob23', this.test[0]);
   // console.log('ob',this.test);
   // console.log('ob2', this.test[0]);
  }
  randomIntFromInterval(min, max) { 
    return Math.floor(Math.random() * (max - min + 1) + min);
    }

    bambne(item : any, so : number, index : number)
  {
    console.log('dd',this.test[index].arr[so].ans,'so', so);
    
    if(this.test[index].arr[so].ans)
    {
     this.test[index].tf=true;
    // this.sai +=1;
    }
    else{
      
      this.test[index].tf=false;
    }

    
    }
    check()
    {
        this.showans = true;
        this.sai = 0;
        this.test.forEach(element => {
        if(element.tf) this.sai+=1;
      });
        this.diem = (100*( this.sai)/ this.test.length).toFixed();
    }

}

class testx {

  arr: {
    word: LearnDto,
    ans: boolean
  }[] ;
  ans: LearnDto;
  tf: boolean;
}
