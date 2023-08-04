import { Component } from '@angular/core';

@Component({
  selector: 'post-secondary-view',
  templateUrl: './post-secondary-view.component.html',
  styleUrls: ['./post-secondary-view.component.scss']
})
export class PostSecondaryViewComponent {
  // UI display
  loadingComplete: boolean = true;
  programs: Array<Program> = new Array<Program>;
}

export interface Program {
  id: number;
  name: string;
  gradeRange: string;
  language: string;
  prerequisites: string;
  website: string;
  universityId: number;
}
