import { Service, signal, WritableSignal } from '@angular/core';
import { defaultPagination } from '../../shared/shared-default-pagination.constants';
import { PaginatedData } from '../../models/paginated-list/paginated-list.interface';

@Service()
export class PaginationStoreSimple {
    simplePaginationStore: WritableSignal<PaginatedData> = signal<PaginatedData>(defaultPagination);
}
