import { Component, OnInit } from '@angular/core';
import { IUser } from 'src/app/Interfaces/iuser';
import { AuthService } from 'src/app/Services/authetication/auth.service';
import { SupplierService } from 'src/app/Services/Supplier/supplier.service';

@Component({
  selector: 'app-supplier-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.scss']
})
export class FormComponent implements OnInit {

  public model = {
    id: null,
    name: '',
    phoneNumber: '',
    emailAddress: '',
    status: true,
    created: null,
    modified: null
  };

  constructor(private _supplier: SupplierService, private _auth: AuthService) { }

  ngOnInit(): void {
  }

  onSubmit(): void {
   
    this._auth.currentUser$.subscribe((resp: IUser | null) => {
      if(resp != null) {
        this._supplier.Post({ ...this.model, userId: resp.userId })
      }
    })
   
  }

}
