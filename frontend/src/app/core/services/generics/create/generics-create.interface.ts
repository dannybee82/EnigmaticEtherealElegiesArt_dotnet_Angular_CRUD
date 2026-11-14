import { WritableSignal } from "@angular/core";

export interface GenericsCreateInterface<T> {
    entity: WritableSignal<T | FormData | undefined>;

    data: WritableSignal<boolean | undefined>;

    isFormData: WritableSignal<boolean>;
}