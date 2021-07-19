import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-mensages-error',
  templateUrl: './mensages-error.component.html',
})
export class MensagesErrorComponent implements OnInit {

  public error: string;
  constructor() { }

  ngOnInit(): void {  }
  
  setError(error: string, tempo: number = 5000) {
    this.error = error;
    setTimeout(() => {
      this.error = null;
    }, tempo);
  }

}
