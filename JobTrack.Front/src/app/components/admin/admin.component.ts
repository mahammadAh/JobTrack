import { Component } from '@angular/core';
import { VacancyListComponent } from "./vacancy-list/vacancy-list.component";
import { VacancyFormComponent } from "./vacancy-form/vacancy-form.component";

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [VacancyListComponent, VacancyFormComponent],
  templateUrl: 'admin.component.html',
  styleUrls: [ 'admin.component.scss' ]
})
export class AdminComponent {

}
