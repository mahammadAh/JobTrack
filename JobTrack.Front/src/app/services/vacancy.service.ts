import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { VacancyResponseDTO } from '../models/vacancy-response-dto.model';
import { ApiResponse } from '../models/api-response.model';
import { ApiRequest } from '../models/api-request.model';
import { Observable } from 'rxjs';
import { VacancyRequestDTO } from '../models/vacancy-request-dto.model';

@Injectable({
  providedIn: 'root'
})
export class VacancyService {
  private apiUrl = 'http://localhost:5118/jobTrack/Vacancy/'; 

  constructor(private http: HttpClient) {}

  getVacancies(): Observable<ApiResponse<VacancyResponseDTO[]>> {
     return this.http.get<ApiResponse<VacancyResponseDTO[]>>(`${this.apiUrl}GetAll`);
  }


  getVacancyById(id: number): Observable<VacancyResponseDTO> {
    return this.http.get<VacancyResponseDTO>(`${this.apiUrl}Get/${id}`);
  }


  createVacancy(request: ApiRequest<VacancyRequestDTO>): Observable<ApiResponse<VacancyResponseDTO>> {
    return this.http.post<ApiResponse<VacancyResponseDTO>>(`${this.apiUrl}Create`, request);
  }


  updateVacancy(request: ApiRequest<VacancyResponseDTO>): Observable<ApiResponse<VacancyResponseDTO>> {
    return this.http.put<ApiResponse<VacancyResponseDTO>>(`${this.apiUrl}Update`, request , {params: { id: request.data.id }});
  }

 
  deleteVacancy(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}Delete`, { params: { id } });
  }
}