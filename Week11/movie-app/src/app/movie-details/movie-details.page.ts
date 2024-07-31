import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { catchError, lastValueFrom } from 'rxjs';
import { Movie } from '../models/movie';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.page.html',
  styleUrls: ['./movie-details.page.scss'],
})
export class MovieDetailsPage implements OnInit {
  movie: Movie | null = null;

  constructor(private http: HttpClient, private route: ActivatedRoute) {}

  ngOnInit() {
    const movieId = this.route.snapshot.paramMap.get('id');
    if (movieId) {
      this.getMovieDetails(movieId);
    }
  }

  async getMovieDetails(movieId: string) {
    try {
      const API_KEY = '20b1cafbbd7e7e7f17b7d3af1779a232'; // Replace with your actual API key
      const URL = `https://api.themoviedb.org/3/movie/${movieId}?api_key=${API_KEY}&language=en-US`;

      this.movie = await lastValueFrom(
        this.http.get<Movie>(URL).pipe(
          catchError((error) => {
            console.error('Error fetching movie details:', error);
            throw error; // Re-throw error to be caught by outer catch block
          })
        )
      );
    } catch (error) {
      console.log('Error fetching movie details:', error);
    }
  }

  getImageUrl(path: string): string {
    return `https://image.tmdb.org/t/p/w500${path}`;
  }

  getGenres(): string {
    return (
      this.movie?.genres?.map((genre) => genre.name).join(', ') ||
      'No genres available'
    );
  }
}
