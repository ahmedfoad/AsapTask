import type { EntityDto } from '@abp/ng.core';

export interface ClientDto extends EntityDto<number> {
  firstName?: string;
  lastName?: string;
  email?: string;
  phoneNumber?: string;
  nationality?: string;
}
