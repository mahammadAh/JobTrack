import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { VacancyService } from '../../../services/vacancy.service';
import { VacancyResponseDTO } from '../../../models/vacancy-response-dto.model';
import { ApplicationFormComponent } from "../application-form/application-form.component";

@Component({
  selector: 'app-vacancy-list',
  standalone: true,
  imports: [CommonModule, ApplicationFormComponent],
  templateUrl: 'vacancy-list.component.html',
  styles: []
})

export class VacancyListComponent {
  @Input() vacancy: VacancyResponseDTO | null = null; 
  vacancies: VacancyResponseDTO[] = [];
  selectedVacancy: VacancyResponseDTO | null = null;

  constructor(private vacancyService: VacancyService) {}

  ngOnInit(): void {
    this.loadVacancies();
  }

  loadVacancies(): void {
    this.vacancyService.getVacancies().subscribe({
      next: (response) => {
        this.vacancies = response.data.filter(vacancy => vacancy.status); 
      },
      error: (error) => {
        console.error(error); 
      }
    });
  }  

  applyForVacancy(vacancy: VacancyResponseDTO) {
    this.selectedVacancy = vacancy;
    console.log(this.selectedVacancy.title);
    
  }
}
