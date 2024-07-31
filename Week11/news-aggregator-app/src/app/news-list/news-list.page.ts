import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NewsService } from '../services/news.service';

@Component({
  selector: 'app-news-list',
  templateUrl: './news-list.page.html',
  styleUrls: ['./news-list.page.scss'],
})
export class NewsListPage implements OnInit {
  articles: any[] = [];
  searchQuery: string = '';

  constructor(private newsService: NewsService, private router: Router) {}

  ngOnInit() {
    this.loadTopHeadlines();
  }

  loadTopHeadlines() {
    this.newsService.getTopHeadlines().subscribe((data) => {
      this.articles = data.articles;
    });
  }

  searchNews() {
    this.newsService.searchNews(this.searchQuery).subscribe((data) => {
      this.articles = data.articles;
    });
  }

  viewArticle(article: any) {
    // Note: This is a placeholder. You may need to pass more unique information.
    this.router.navigate(['/news-details', { id: article.source.id }]);
  }
}
