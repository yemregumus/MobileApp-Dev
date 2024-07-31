import { Component, OnInit } from '@angular/core';
import { RecipeService } from '../services/recipe.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.page.html',
  styleUrls: ['./home.page.scss'],
})
export class HomePage implements OnInit {
  recipes: any[] = [];
  searchQuery: string = '';

  constructor(private recipeService: RecipeService) {}

  ngOnInit() {
    this.loadRandomRecipes();
  }

  loadRandomRecipes() {
    this.recipeService.getRandomRecipes().subscribe((data) => {
      this.recipes = data.recipes;
    });
  }

  searchRecipes() {
    if (this.searchQuery.trim() === '') {
      this.loadRandomRecipes();
    } else {
      this.recipeService.searchRecipes(this.searchQuery).subscribe((data) => {
        this.recipes = data.results;
      });
    }
  }
}
