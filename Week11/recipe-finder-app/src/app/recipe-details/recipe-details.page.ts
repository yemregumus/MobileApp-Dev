import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RecipeService } from '../services/recipe.service';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

@Component({
  selector: 'app-recipe-details',
  templateUrl: './recipe-details.page.html',
  styleUrls: ['./recipe-details.page.scss'],
})
export class RecipeDetailsPage implements OnInit {
  recipe: any;
  summary: SafeHtml | undefined;
  instructions: SafeHtml | undefined;

  constructor(
    private route: ActivatedRoute,
    private recipeService: RecipeService,
    private sanitizer: DomSanitizer
  ) {}

  ngOnInit() {
    const recipeId = this.route.snapshot.paramMap.get('id');
    if (recipeId) {
      this.recipeService.getRecipeDetails(recipeId).subscribe((data) => {
        this.recipe = data;
        this.summary = this.sanitizer.bypassSecurityTrustHtml(
          this.recipe.summary
        );
        this.instructions = this.sanitizer.bypassSecurityTrustHtml(
          this.recipe.instructions
        );
      });
    }
  }
}
