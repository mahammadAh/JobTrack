import { Component } from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { VacancyService } from '../../../services/vacancy.service';
import { VacancyResponseDTO } from '../../../models/vacancy-response-dto.model';

@Component({
  selector: 'app-admin-vacancy-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: 'vacancy-list.component.html',
  styles: []
})

export class VacancyListComponent {
  vacancies: VacancyResponseDTO[] = [];

  constructor(private vacancyService: VacancyService) {}

  ngOnInit(): void {
    this.loadVacancies();
  }

  loadVacancies(): void {
    this.vacancyService.getVacancies().subscribe({
      next: (response) => {
        this.vacancies = response.data; 
      },
      error: (error) => {
        console.error(error); 
      }
    });
  }  

  deleteVacancy(id: string): void {
    this.vacancyService.deleteVacancy(id).subscribe({
      next: () => {
        console.log('Vacancy deleted');
        this.loadVacancies(); 
      },
      error: (err) => {
        console.error('Error deleting vacancy', err);
      }
    });
  }
}
