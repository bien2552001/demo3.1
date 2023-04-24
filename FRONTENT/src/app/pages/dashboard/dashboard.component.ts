import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import * as moment from 'moment';
import { DashBoardModel } from './dashboard.model';
import { DashboardService } from './dashboard.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  constructor(private http: DashboardService) { }
  //Ngày
  public dtsu_ngay!: Array<DashBoardModel>;
  public dtsu1_ngay!: Array<DashBoardModel>;
  public dtsu2_ngay!: Array<DashBoardModel>;
  public pzem_ngay!: Array<DashBoardModel>;
  ngOnInit(): void {
    this.DTSU_ngay();
    this.DTSU1_ngay();
    this.DTSU2_ngay();
    this.PZEM_ngay();

    document.getElementById("today")?.click();
    setTimeout(() => {
      document.getElementById("today")?.click();
    }, 100);
  }
  DTSU_ngay() {
    this.http.DTSU_upha().subscribe(upha => {
      this.dtsu_ngay = upha;
    })
  }
  DTSU1_ngay() {
    this.http.DTSU_cs().subscribe(cs => {
      this.dtsu1_ngay = cs;
    })
  }
  DTSU2_ngay() {
    this.http.DTSU_cs1().subscribe(cs => {
      this.dtsu2_ngay = cs;
    })
  }

  PZEM_ngay() {
    this.http.Pzem_da().subscribe(da => {
      this.pzem_ngay = da;
    })
  }
  ngAfterViewInit() {
    const t = document.getElementById("today");
    const w = document.getElementById("week");
    const m = document.getElementById("month");
    const y = document.getElementById("year");
    const date = document.getElementById("date");

    // logic for today button when the user is on dashboard
    t?.addEventListener('click', () => {
      date!.innerHTML = moment().format('MMMM, Do YYYY');
    });

    w?.addEventListener('click', () => {
      const startOfWeek = moment().startOf('week').format('MMMM Do');
      const endOfWeek = moment().endOf('week').format('MMMM Do, YYYY');
      date!.innerHTML = `From ${startOfWeek} to ${endOfWeek}`;
    });

    // logic for month button when the user is on dashboard
    m?.addEventListener('click', () => {
      date!.innerHTML = moment().format('MMMM, YYYY');
    });

    // logic for year button when the user is on dashboard
    y?.addEventListener('click', () => {
      date!.innerHTML = moment().format('YYYY');
    });

  }

}
