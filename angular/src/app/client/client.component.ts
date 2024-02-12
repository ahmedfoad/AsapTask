import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClientService } from '@proxy/clients';
import { ClientDto } from '@proxy/clients/dto/models';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { DataBindingDirective, GridDataResult, PageChangeEvent, PagerPosition, PagerType } from '@progress/kendo-angular-grid';
import { SVGIcon, filePdfIcon } from '@progress/kendo-svg-icons';
import { process } from "@progress/kendo-data-query";
import { GoogleMapsService } from '../services/googleMaps.service';

@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrl: './client.component.scss',
  providers: [ListService],
})
export class ClientComponent implements OnInit {
  public clientsList: ClientDto[];
  isModalOpen = false; // add this line
  form: FormGroup; // add this line
  selectedClient = {} as ClientDto;
  countries: string[];

  constructor(public readonly list: ListService,
    private clientService: ClientService,
    private fb: FormBuilder, // inject FormBuilder
    private confirmation: ConfirmationService, // inject the ConfirmationService
    private googleMapsService: GoogleMapsService
  ) { }

  ngOnInit() {
    this.getAllClients();

    this.googleMapsService.getCountries().subscribe(countries => {
      this.countries = countries;
      debugger;
      var x =1;
    });
  }

  getAllClients() {
    this.clientService.getAll()
      .subscribe(
        (clients: ClientDto[]) => {
          this.clientsList = clients;
          console.log(clients);
        },
        (error) => {
          // Handle error
          console.error('Error fetching clients:', error);
        }
      );
  }

  create() {
    this.selectedClient = {} as ClientDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  edit(id: number) {
    this.clientService.get(id).subscribe((client) => {
      this.selectedClient = client;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  // add buildForm method
  buildForm() {
    this.form = this.fb.group({
      firstName: [this.selectedClient.firstName || ''],
      lastName: [this.selectedClient.lastName || ''],
      email: [this.selectedClient.email || null],
      phoneNumber: [this.selectedClient.phoneNumber || null],
      nationality: [this.selectedClient.nationality || null],
    });
  }

  // add save method
  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedClient.id
      ? this.clientService.update(this.selectedClient.id, this.form.value)
      : this.clientService.create(this.form.value);

    request.subscribe(() => {
      this.isModalOpen = false;
      this.form.reset();
      this.list.get();
    });

    this.getAllClients();
  }

  // Add a delete method
delete(id: number) {
  this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
    if (status === Confirmation.Status.confirm) {
      this.clientService.delete(id).subscribe(() => this.list.get());
      this.getAllClients();
    }
  });
}
}


