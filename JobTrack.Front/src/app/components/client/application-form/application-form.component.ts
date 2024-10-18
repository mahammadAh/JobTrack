import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { FormsModule } from '@angular/forms';
import { ApiRequest } from '../../../models/api-request.model';
import { VacancyRequestDTO } from '../../../models/vacancy-request-dto.model';
import { VacancyResponseDTO } from '../../../models/vacancy-response-dto.model';
import { ApplicationFormResponseDTO } from '../../../models/application-form-response-dto.model';
import { ApplicationFormRequestDTO } from '../../../models/application-form-request-dto.model';
import { ApplicationFormService } from '../../../services/application-form.service';


@Component({
  selector: 'app-application-form',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: 'application-form.component.html',
  styles: []
})

export class ApplicationFormComponent {
   @Input() vacancy: VacancyResponseDTO | null = null;
   @Output() close = new EventEmitter<void>();

   constructor(private ApplicationFormService: ApplicationFormService) {}

    applicationForm : ApplicationFormRequestDTO= {
    name: '',
    surname: '',
    email: '',
    phone: ''
  };

  submitApplication() {
    const request: ApiRequest<ApplicationFormRequestDTO> = { data: this.applicationForm};

    this.ApplicationFormService.createApplicationForm(request).subscribe({
      next: (response) => {
        console.log('Application Form created', response);
      },
      error: (err) => {
        console.error('Aplication Form create error', err);
      },
    });
  }

  exit() {
    this.close.emit(); 
  }
}
