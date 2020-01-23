import { async, ComponentFixture, TestBed } from "@angular/core/testing";
import { TripFormComponent } from "./trip-form.component";
import { FormsModule } from '@angular/forms';
import {HttpModule, Http} from "@angular/http";
import { DlDateTimeDateModule, DlDateTimePickerModule } from "angular-bootstrap-datetimepicker";
import { HttpClient, HttpHandler } from "@angular/common/http";
describe("TripFormComponent", () => {
  let component: TripFormComponent;
  let fixture: ComponentFixture<TripFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [TripFormComponent],
      imports:[FormsModule, HttpModule, DlDateTimeDateModule, DlDateTimePickerModule],
      providers: [HttpClient, HttpHandler],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TripFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should be created", () => {
    const fixture = TestBed.createComponent(TripFormComponent);
    const app = fixture.debugElement.componentInstance;
    expect(app).toBeTruthy();
  });
});
