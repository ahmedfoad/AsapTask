import type { PolygonDataDto } from './dto/models';
import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PolygonService {
  apiName = 'Default';
  

  create = (polygonDataDto: PolygonDataDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: '/api/app/polygon',
      body: polygonDataDto,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
