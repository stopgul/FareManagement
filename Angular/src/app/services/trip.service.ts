import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";
import { retry, catchError } from "rxjs/operators";
import { Trip } from "../models/trip";

@Injectable({
  providedIn: "root"
})
export class TripService {
  baseUrl: string = "https://localhost:44308/api/v1/fair";

  constructor(private http: HttpClient) {}

  getRate(trip: Trip): Observable<number> {
    let params = this.prepareGetRateParams(trip);
    return this.http
      .get<number>(this.baseUrl, { params: params })
      .pipe(retry(1));
  }

  private prepareGetRateParams(trip: Trip) {
    let params = new HttpParams();
    params = params.append(
      "LessThan6MilesPerHourSpeedRangeIndicator",
      trip.lessThan6MilesPerHourSpeedRangeIndicator.toString()
    );
    params = params.append(
      "MoreThan6MilesPerHourOr60SecondsDurationIndicator",
      trip.moreThan6MilesPerHourOr60SecondsDurationIndicator.toString()
    );
    params = params.append(
      "TripDate",
      trip.tripDate.toString().replace(" GMT-0500 (Eastern Standard Time)", "")
    );
    return params;
  }
}
