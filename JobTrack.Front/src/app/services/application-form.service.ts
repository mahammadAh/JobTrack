import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiResponse } from '../models/api-response.model';
import { ApiRequest } from '../models/api-request.model';
import { Observable } from 'rxjs';
import { ApplicationFormResponseDTO } from '../models/application-form-response-dto.model';
import { ApplicationFormRequestDTO } from '../models/application-form-request-dto.model';

@Injectable({
  providedIn: 'root'
})
export class ApplicationFormService {
  private apiUrl = 'http://localhost:5118/jobTrack/ApplicationForm/'; 

  constructor(private http: HttpClient) {}

  getApplicationForms(): Observable<ApiResponse<ApplicationFormResponseDTO[]>> {
     return this.http.get<ApiResponse<ApplicationFormResponseDTO[]>>(`${this.apiUrl}GetAll`);
  }


  getApplicationFormId(id: number): Observable<ApplicationFormResponseDTO> {
    return this.http.get<ApplicationFormResponseDTO>(`${this.apiUrl}Get/${id}`);
  }


  createApplicationForm(request: ApiRequest<ApplicationFormRequestDTO>): Observable<ApiResponse<ApplicationFormResponseDTO>> {
    return this.http.post<ApiResponse<ApplicationFormResponseDTO>>(`${this.apiUrl}Create`, request);
  }

}