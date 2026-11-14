import { Signal } from "@angular/core";
import { PaginatedList } from "../../../models/paginated-list/paginated-list.interface";

export interface GenericsAllPagedListInterface<T> {   
    data: Signal<PaginatedList<T> | undefined>    

    hasValue: Signal<boolean>;
}