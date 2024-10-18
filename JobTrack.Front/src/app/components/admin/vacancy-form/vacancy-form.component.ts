import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { VacancyService } from '../../../services/vacancy.service';
import { VacancyRequestDTO } from '../../../models/vacancy-request-dto.model';
import { ApiRequest } from '../../../models/api-request.model';
import { VacancyResponseDTO } from '../../../models/vacancy-response-dto.model';

@Component({
  selector: 'app-admin-vacancy-form',
  standalone: true,
  imports: [FormsModule],
  templateUrl: 'vacancy-form.component.html',
  styles : []
})

export class VacancyFormComponent {

  vacancyCreate: VacancyRequestDTO = {
    title: '',
    description: '',
    deadline: new Date(),
    status: true,
  };

  vacancyUpdate: VacancyResponseDTO = {
    id: '',
    title: '',
    description: '',
    deadline: new Date(),
    status: true,
  }

  isEditMode: boolean = false;

  constructor(private vacancyService: VacancyService) {}

  onSubmit() {
    if (this.isEditMode) {
      this.updateVacancy();
    } else {
      this.createVacancy();
    }
  }

  createVacancy() {
    const request: ApiRequest<VacancyRequestDTO> = { data: this.vacancyCreate };

    this.vacancyService.createVacancy(request).subscribe({
      next: (response) => {
        console.log('Vacancy created', response);
      },
      error: (err) => {
        console.error('Vacancy create error', err);
      },
    });
  }

  updateVacancy() {
    const request: ApiRequest<VacancyResponseDTO> = { data: this.vacancyUpdate };

    this.vacancyService.updateVacancy(request).subscribe({
      next: (response) => {
        console.log('Vacancy updated', response);
      },
      error: (err) => {
        console.error('Vacancy update error', err);
      },
    });
  }

  
}
