import { Component, Input, OnInit } from '@angular/core';
import { Member } from 'src/app/_models/member';

@Component({
  selector: '[userTableRow]',
  templateUrl: './user-table-row.component.html',
  styleUrls: ['./user-table-row.component.scss']
})
export class UserTableRowComponent implements OnInit {

  @Input() member: Member;

  constructor() { }

  ngOnInit(): void {
  }

}
