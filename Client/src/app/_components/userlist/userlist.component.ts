import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Member } from 'src/app/_models/member';
import { MembersService } from 'src/app/_services/members.service';
import { WordsService } from 'src/app/_services/words.service';

@Component({
  selector: 'app-userlist',
  templateUrl: './userlist.component.html',
  styleUrls: ['./userlist.component.scss']
})
export class UserlistComponent implements OnInit {
  
  members$: Observable<Member[]>;


  constructor(private memberService: MembersService) { }

  ngOnInit(): void {
    this.members$ = this.memberService.getMembers();
    console.log(this.members$)
  }



}
