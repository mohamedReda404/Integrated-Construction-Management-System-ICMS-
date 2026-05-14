import {
  Component,
  OnInit,
  ViewChild,
  ElementRef,
  AfterViewChecked
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ChatService, ChatMessage, ChatRequest } from './chat.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AuthService } from './../../core/auth/services/auth.service';
import { RouterModule } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-chat',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.scss'],
})
export class ChatComponent implements OnInit, AfterViewChecked {
  @ViewChild('messagesContainer') private messagesContainer!: ElementRef;
  @ViewChild('messageInput') private messageInput!: ElementRef;

  messages: ChatMessage[] = [];
  userInput = '';
  isLoading = false;
  errorMessage = '';
  userData: any;

  constructor(
    private chatService: ChatService,
    private http: HttpClient,
    private cookie: CookieService
  ) {}

  ngOnInit(): void {
    // Welcome message
    this.messages.push({
      role: 'assistant',
      content: 'Hello! How can I help you today?',
      timestamp: new Date()
      
    });
    this.loadUserInfo();
  }

  ngAfterViewChecked(): void {
    this.scrollToBottom();
  }

 sendMessage(): void {
  const text = this.userInput.trim();
  if (!text || this.isLoading) return;

  this.messages.push({
    role: 'user',
    content: text,
    timestamp: new Date()
  });

  this.userInput = '';
  this.isLoading = true;

  const request: ChatRequest = {
    message: text,
    conversationHistory: this.messages
      .slice(0, -1)
      .map(m => ({ role: m.role, content: m.content }))
  };

  this.chatService.sendMessage(request).subscribe({
    next: (res) => {
      this.messages.push({
        role: 'assistant',
        content: res.response,
        timestamp: new Date()
      });
      this.isLoading = false;
    },

    error: (err) => {
      console.error(err);
      this.isLoading = false;
    },

    complete: () => {
      this.isLoading = false;
    }
  });
}

  onKeyDown(event: KeyboardEvent): void {
    if (event.key === 'Enter' && !event.shiftKey) {
      event.preventDefault();
      this.sendMessage();
    }
  }

  clearChat(): void {
    this.messages = [{
      role: 'assistant',
      content: 'Hello! How can I help you today?',
      timestamp: new Date()
    }];
    this.errorMessage = '';
  }

 loadUserInfo(): void {

    const token = this.cookie.get('token');

    if (!token) return;

    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`
    });

    this.http.get<any>(
      `https://localhost:7139/me/Info`,
      { headers }
    ).subscribe({

      next: (res: any) => {
        this.userData = res;
        console.log('User Info:', res);
      },

      error: (err: any) => {
        console.error('Failed to load user info', err);
      }

    });
  }



  private scrollToBottom(): void {
    try {
      this.messagesContainer.nativeElement.scrollTop =
        this.messagesContainer.nativeElement.scrollHeight;
    } catch (e) {}
  }
}
