import { Component, OnInit } from '@angular/core';
import {DecimalPipe} from '@angular/common';
import {QueryList, ViewChildren} from '@angular/core';
import {Observable} from 'rxjs';

import {Country} from './country';
import {CountryService} from './country.service';
import {NgbdSortableHeader, SortEvent} from './sortable.directive';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-instructor-list',
  templateUrl: './instructor-list.component.html',
  styleUrls: ['./instructor-list.component.css'],
  providers: [CountryService, DecimalPipe]
})
export class InstructorListComponent implements OnInit {
  countries$!: Observable<Country[]>;
  total$!: Observable<number>;
  
  @ViewChildren(NgbdSortableHeader) headers!: QueryList<NgbdSortableHeader>;
  
  onSort({column, direction}: SortEvent) {
    // resetting other headers
    this.headers.forEach(header => {
      if (header.sortable !== column) {
        header.direction = '';
      }
    });

    this.service.sortColumn = column;
    this.service.sortDirection = direction;
  }

  modalRef!: BsModalRef;
  constructor(public service: CountryService) {
    this.countries$ = service.countries$;
    this.total$ = service.total$;
  }
  
  ngOnInit(): void {
  }

}
