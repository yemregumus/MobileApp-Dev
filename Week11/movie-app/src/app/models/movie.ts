// src/app/models/movie.ts

export interface Genre {
  id: number;
  name: string;
}

export interface Movie {
  id: number;
  title: string;
  release_date: string;
  poster_path: string;
  overview: string;
  genres: Genre[];
}
