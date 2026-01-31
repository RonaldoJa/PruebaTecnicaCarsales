import { Injectable, signal } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Episode } from '../models/episode';
import { environment } from '../../environments/environment';
import { EpisodesResponse } from '../models/episodesResponse';

@Injectable({
  providedIn: 'root'
})
export class EpisodeService {
  private readonly API_URL = environment.apiUrl;
  
  episodes = signal<Episode[]>([]);
  loading = signal<boolean>(false);
  error = signal<string | null>(null);
  currentPage = signal<number>(1);
  totalPages = signal<number>(1);
  
  constructor(private http: HttpClient) {}
  
  loadEpisodes(page: number = 1, name?: string, episode?: string): void {
    this.loading.set(true);
    this.error.set(null);
    
    let params = new HttpParams().set('page', page.toString());
    if (name) params = params.set('name', name);
    if (episode) params = params.set('episode', episode);
    
    this.http.get<EpisodesResponse>(this.API_URL, { params })
      .subscribe({
        next: (response) => {
          this.episodes.set(response.results);
          this.currentPage.set(page);
          this.totalPages.set(response.info.pages);
          this.loading.set(false);
        },
        error: (err) => {
          this.error.set('Error al cargar episodios');
          this.loading.set(false);
          console.error(err);
        }
      });
  }
}
