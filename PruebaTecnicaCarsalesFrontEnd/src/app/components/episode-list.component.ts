import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { EpisodeService } from '../services/episode.service';

@Component({
  selector: 'app-episode-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <div class="container">
      <h1>Rick and Morty - Episodios</h1>
      
      <div class="search">
        <input 
          [(ngModel)]="searchName" 
          placeholder="Buscar por nombre"
          (keyup.enter)="search()">
        <input 
          [(ngModel)]="searchEpisode" 
          placeholder="Código (ej: S01E01)"
          (keyup.enter)="search()">
        <button (click)="search()">Buscar</button>
        <button (click)="clear()">Limpiar</button>
      </div>

      @if (service.loading()) {
        <div class="loading">Cargando...</div>
      } @else if (service.error()) {
        <div class="error">{{ service.error() }}</div>
      } @else {
        <div class="grid">
          @for (episode of service.episodes(); track episode.id) {
            <div class="card">
              <h3>{{ episode.name }}</h3>
              <p><strong>{{ episode.episode }}</strong></p>
              <p>{{ episode.airDate }}</p>
              <p>{{ episode.characters.length }} personajes</p>
            </div>
          }
        </div>

        <div class="pagination">
          <button 
            (click)="prevPage()" 
            [disabled]="service.currentPage() === 1">
            Anterior
          </button>
          <span>Página {{ service.currentPage() }} de {{ service.totalPages() }}</span>
          <button 
            (click)="nextPage()" 
            [disabled]="service.currentPage() === service.totalPages()">
            Siguiente
          </button>
        </div>
      }
    </div>
  `,
  styles: [`
    .container { max-width: 1200px; margin: 0 auto; padding: 20px; }
    h1 { text-align: center; color: #333; }
    .search { display: flex; gap: 10px; margin: 20px 0; }
    .search input { flex: 1; padding: 10px; border: 1px solid #ddd; border-radius: 4px; }
    .search button { padding: 10px 20px; background: #4CAF50; color: white; border: none; border-radius: 4px; cursor: pointer; }
    .loading, .error { text-align: center; padding: 20px; }
    .error { color: red; }
    .grid { display: grid; grid-template-columns: repeat(auto-fill, minmax(250px, 1fr)); gap: 20px; margin: 20px 0; }
    .card { border: 1px solid #ddd; padding: 15px; border-radius: 8px; background: white; }
    .card h3 { margin: 0 0 10px 0; color: #333; }
    .pagination { display: flex; justify-content: center; align-items: center; gap: 20px; margin: 20px 0; }
    .pagination button { padding: 10px 20px; background: #4CAF50; color: white; border: none; border-radius: 4px; cursor: pointer; }
    .pagination button:disabled { background: #ccc; cursor: not-allowed; }
  `]
})
export class EpisodeListComponent implements OnInit {
  service = inject(EpisodeService);
  searchName = '';
  searchEpisode = '';

  ngOnInit() {
    this.service.loadEpisodes();
  }

  search() {
    this.service.loadEpisodes(1, this.searchName || undefined, this.searchEpisode || undefined);
  }

  clear() {
    this.searchName = '';
    this.searchEpisode = '';
    this.service.loadEpisodes(1);
  }

  nextPage() {
    this.service.loadEpisodes(
      this.service.currentPage() + 1,
      this.searchName || undefined,
      this.searchEpisode || undefined
    );
  }

  prevPage() {
    this.service.loadEpisodes(
      this.service.currentPage() - 1,
      this.searchName || undefined,
      this.searchEpisode || undefined
    );
  }
}
