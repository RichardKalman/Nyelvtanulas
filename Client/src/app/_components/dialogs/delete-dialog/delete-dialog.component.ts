import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import {  } from 'ngx-bootstrap/modal/modal-options.class';
import { Subject } from 'rxjs/internal/Subject';

@Component({
  selector: 'app-delete-dialog',
  templateUrl: './delete-dialog.component.html',
  styleUrls: ['./delete-dialog.component.scss']
})
export class DeleteDialogComponent implements OnInit {
  
    public onClose: Subject<boolean>;
    public deleteText: string;

    constructor(public _bsModalRef: BsModalRef) { }

    public ngOnInit(): void {
        this.onClose = new Subject();
    }

    public onConfirm(): void {
        this.onClose.next(true);
        this._bsModalRef.hide();
    }

    public onCancel(): void {
        this.onClose.next(false);
        this._bsModalRef.hide();
    }
}


