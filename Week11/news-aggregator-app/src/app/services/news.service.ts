import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class NewsService {
  apiKey: string = 'key here';
  apiUrl: string = 'https://newsapi.org/v2';

  constructor(private http: HttpClient) {}

  getTopHeadlines(): Observable<any> {
    return this.http.get(
      `${this.apiUrl}/top-headlines?country=us&apiKey=${this.apiKey}`
    );
  }

  searchNews(query: string): Observable<any> {
    return this.http.get(
      `${this.apiUrl}/everything?q=${query}&apiKey=${this.apiKey}`
    );
  }

  getArticleById(articleId: string): Observable<any> {
    // Note: This is a placeholder. Replace this with the appropriate method to get a specific article by ID.
    return this.http.get(
      `${this.apiUrl}/everything?q=id:${articleId}&apiKey=${this.apiKey}`
    );
  }
}
