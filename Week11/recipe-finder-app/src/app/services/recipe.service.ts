import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class RecipeService {
  private apiKey = '46be5e168db24e0f9f4caa875c4e6235';
  private apiUrl = 'https://api.spoonacular.com/recipes';

  constructor(private http: HttpClient) {}

  getRandomRecipes(): Observable<any> {
    return this.http.get(
      `${this.apiUrl}/random?apiKey=${this.apiKey}&number=10`
    );
  }

  searchRecipes(query: string): Observable<any> {
    return this.http.get(
      `${this.apiUrl}/complexSearch?apiKey=${this.apiKey}&query=${query}`
    );
  }

  getRecipeDetails(id: string): Observable<any> {
    return this.http.get(
      `${this.apiUrl}/${id}/information?apiKey=${this.apiKey}`
    );
  }
}
