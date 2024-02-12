import { RestService, Rest } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class StockMarketService {
  apiName = 'Default';
  

  fetchMarketStockData = (config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'POST',
      url: '/api/app/stock-market/fetch-market-stock-data',
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
