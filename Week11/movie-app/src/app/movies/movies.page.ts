import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.page.html',
  styleUrls: ['./movies.page.scss'],
})
export class MoviesPage implements OnInit {
  movies: any[] = [];
  searchQuery: string = '';

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getTopRatedMovies();
  }

  getTopRatedMovies() {
    const url = `https://api.themoviedb.org/3/movie/top_rated?api_key=${environment.tmdbApiKey}&language=en-US&page=1`;
    this.http.get<any>(url).subscribe((response) => {
      this.movies = response.results;
    });
  }

  searchMovies() {
    if (this.searchQuery.trim() === '') {
      this.getTopRatedMovies();
    } else {
      const url = `https://api.themoviedb.org/3/search/movie?api_key=${environment.tmdbApiKey}&query=${this.searchQuery}`;
      this.http.get<any>(url).subscribe((response) => {
        this.movies = response.results;
      });
    }
  }

  getImageUrl(path: string) {
    return `https://image.tmdb.org/t/p/w500${path}`;
  }
}
