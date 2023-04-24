import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import * as moment from 'moment';
import { Observable } from 'rxjs';
import { DashBoardModel } from './dashboard.model';

@Injectable({
  providedIn: 'root'
})
export class DashboardService {


  BaseUrl = "https://localhost:5001"
  // Post-Test
  postcurrent(data: any): Observable<Array<DashBoardModel>> {
    return this.http.post<Array<DashBoardModel>>('https://localhost:5001/dtsu666', data);
  }




  timedaya = moment().startOf('day').format("YYYY-MM-DDTHH:mm:ss")
  timedayb = moment().endOf('day').format("YYYY-MM-DDTHH:mm:ss")
  timeweek = moment().endOf('day').subtract(7, 'day').format("YYYY-MM-DDTHH:mm:ss")
  timemonth = moment().endOf('day').subtract(30, 'day').format("YYYY-MM-DDTHH:mm:ss")


  constructor(private http: HttpClient) { }

  //-----------------------------------------------------------------------------------------Ngày --------------------------------------------------------------
  //---------------------------------------------------------------------DTSU66------------------------------
  //---------------Điện áp pha,Điện áp dây, Dòng điện pha ----------------
  DTSU_upha() {
    return this.http.get<Array<DashBoardModel>>(this.BaseUrl + '/dtsu666?&Fields=Ua,Ub,Uc,Uab,Ubc,Uca,Ia,Ib,Ic&start=' + this.timedaya + '&end=' + this.timedayb)
  }
  //---------------Công suất theo pha: p,q ; Cosphi ; Hz ----------------
  DTSU_cs() {
    return this.http.get<Array<DashBoardModel>>(this.BaseUrl + '/dtsu666?&Fields=Pft,Pfa,Pfb,Pfc,Qft,Qfa,Qfb,Qfc,Cosft,Cosfa,Cosfb,Cosfc,Hz&start=' + this.timedaya + '&end=' + this.timedayb)
  }
  //-------------Công suất -------------------
  DTSU_cs1() {
    return this.http.get<Array<DashBoardModel>>(this.BaseUrl + '/dtsu666?&Fields=A_sum,A_imp,A_exp,Q1,Q2,Q3,Q4&start=' + this.timedaya + '&end=' + this.timedayb)
  }


  //---------------------------------------------------------------------PZEM-017------------------------------
  Pzem_da() {
    return this.http.get<Array<DashBoardModel>>(this.BaseUrl + '/pzem017?&Fields=U1&start=' + this.timedaya + '&end=' + this.timedayb)
  }


  //---------------------------------------------------------------------Tuần----------------------------------------------------
  GetTimeweek() {
    return this.http.get(this.BaseUrl + '/dtsu666?&Fields=Hz&start=' + this.timeweek + '&end=' + this.timedayb)
  }
  GetTimemonth() {
    return this.http.get(this.BaseUrl + '/dtsu666?start=' + this.timemonth + '&end=' + this.timedayb)
  }
}

