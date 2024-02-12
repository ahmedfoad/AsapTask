import type { EntityDto } from '@abp/ng.core';

export interface PolygonDataDto extends EntityDto<number> {
  status?: string;
  from?: string;
  symbol?: string;
  open: number;
  high: number;
  low: number;
  close: number;
  volume: number;
  afterHours: number;
  preMarket: number;
}
