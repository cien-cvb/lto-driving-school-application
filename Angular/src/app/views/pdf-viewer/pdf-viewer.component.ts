import { Component, OnInit } from '@angular/core';

import { pdfDefaultOptions } from 'ngx-extended-pdf-viewer';

@Component({
  selector: 'app-pdf-viewer',
  templateUrl: './pdf-viewer.component.html',
  styleUrls: ['./pdf-viewer.component.css']
})
export class PdfViewerComponent implements OnInit {

  constructor() {
    
   }

  ngOnInit(): void {
  }

  doc = "assets/cert.pdf"

  public page = 2;

  public pageLabel: string; 

}
