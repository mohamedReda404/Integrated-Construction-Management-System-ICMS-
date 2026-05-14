import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from './environment';
import { CookieService } from 'ngx-cookie-service';

export interface ChatMessage {
  role: 'user' | 'assistant';
  content: string;
  timestamp: Date;
}

export interface ChatRequest {
  message: string;
  conversationHistory?: { role: string; content: string }[];
}

export interface ChatResponse {
  response: string;
}

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  private apiUrl = `${environment.apiUrl}/Chat`;

  constructor(
    private http: HttpClient,
    private cookie: CookieService
  ) {}

  sendMessage(request: ChatRequest): Observable<ChatResponse> {

    // 👇 get token from cookie (or change to localStorage if you use it)
    const token = this.cookie.get('token');

    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: token ? `Bearer ${token}` : ''
    });

    return this.http.post<ChatResponse>(
      this.apiUrl,
      request,
      { headers }
    );
  }
}