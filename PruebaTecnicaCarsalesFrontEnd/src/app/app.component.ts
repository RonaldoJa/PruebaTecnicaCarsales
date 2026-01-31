import { Component } from '@angular/core';
import { EpisodeListComponent } from './components/episode-list.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [EpisodeListComponent],
  template: `<app-episode-list></app-episode-list>`
})
export class AppComponent {}