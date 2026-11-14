import { WritableSignal } from "@angular/core";

export interface GenericsUpdateInterface<T> {
    entity: WritableSignal<T | FormData | undefined>;

    data: WritableSignal<boolean | undefined>;

    isFormData: WritableSignal<boolean>;
}