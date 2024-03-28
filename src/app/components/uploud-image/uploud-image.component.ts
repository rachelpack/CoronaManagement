import { Component } from '@angular/core';

@Component({
  selector: 'app-uploud-image',
  templateUrl: './uploud-image.component.html',
  styleUrls: ['./uploud-image.component.css']
})

export class UploudImageComponent {
  selectedFile: File | null = null;
  imageUrl: string | ArrayBuffer | null = "";

  onFileSelected(event: any): void {
    const file = event.target.files[0];
    if (file) {
      this.selectedFile = file;
      this.previewImage();
    }
  }

  previewImage(): void {
    const reader = new FileReader();
    reader.readAsDataURL(this.selectedFile as File);
    reader.onload = () => {
      this.imageUrl = reader.result;
    };
  }
}

