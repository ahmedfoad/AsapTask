import { ListService, PagedResultDto } from '@abp/ng.core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ClientService } from '@proxy/clients';
import { ClientDto } from '@proxy/clients/dto/models';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';


@Component({
  selector: 'app-client',
  templateUrl: './client.component.html',
  styleUrl: './client.component.scss',
  providers: [ListService],
})
export class ClientComponent implements OnInit {
  client = { items: [], totalCount: 0 } as PagedResultDto<ClientDto>;
  isModalOpen = false; // add this line
  form: FormGroup; // add this line
  selectedClient = {} as ClientDto;

  constructor(public readonly list: ListService,
    private clientService: ClientService,
    private fb: FormBuilder, // inject FormBuilder
    private confirmation: ConfirmationService // inject the ConfirmationService
  ) { }

  ngOnInit() {
    const clientStreamCreator = (query) => this.clientService.getList(query);

    this.list.hookToQuery(clientStreamCreator).subscribe((response) => {
      this.client = response;
    });
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
      firstName: [this.selectedClient.firstName || '', Validators.required],
      lastName: [this.selectedClient.lastName || '', Validators.required],
      email: [this.selectedClient.email || null, Validators.required],
      phoneNumber: [this.selectedClient.phoneNumber || null, Validators.required],
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
  }

  // Add a delete method
delete(id: number) {
  this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {
    if (status === Confirmation.Status.confirm) {
      this.clientService.delete(id).subscribe(() => this.list.get());
    }
  });
}
}
