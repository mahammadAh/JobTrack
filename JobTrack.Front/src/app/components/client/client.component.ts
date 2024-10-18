import { Component } from '@angular/core';
import { VacancyListComponent } from './vacancy-list/vacancy-list.component';
@Component({
  selector: 'app-client',
  standalone: true,
  imports: [VacancyListComponent],
  templateUrl: 'client.component.html',
  styleUrls: [ 'client.component.scss' ]
})

export class ClientComponent {

}
