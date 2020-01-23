import { Component, OnInit } from "@angular/core";
import { Trip } from "src/app/models/trip";
import { TripService } from "src/app/services/trip.service";

@Component({
  selector: "app-trip-form",
  templateUrl: "./trip-form.component.html",
  styleUrls: ["./trip-form.component.css"]
})
export class TripFormComponent implements OnInit {
  trip: any = {};
  rate: number = 0;

  constructor(private tripService: TripService) {}

  ngOnInit() {}

  getRate() {
    console.log("getRate is started.");
    console.log("date:" + this.trip.tripDate);
    console.log("params:" + JSON.stringify(this.trip));
    const result = this.tripService.getRate(this.trip).subscribe(res => {
      this.rate = res;
    });
  }
}
