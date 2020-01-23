import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AppComponent } from "./app.component";
import { TripFormComponent } from "./components/trip-form/trip-form.component";
import { RouterModule, Routes } from "@angular/router";
import { PageNotFoundComponent } from "./components/page-not-found/page-not-found.component";
import { HttpClientModule } from "@angular/common/http";
import { DlDateTimeDateModule, DlDateTimePickerModule } from 'angular-bootstrap-datetimepicker';
 
const routes: Routes = [
  { path: "", redirectTo: "trip", pathMatch: "full" },
  { path: "trip", component: TripFormComponent },
  { path: "**", component: PageNotFoundComponent }
];

@NgModule({
  declarations: [AppComponent, TripFormComponent, PageNotFoundComponent],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(routes),
    HttpClientModule,
    DlDateTimeDateModule,  // <--- Determines the data type of the model
    DlDateTimePickerModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
