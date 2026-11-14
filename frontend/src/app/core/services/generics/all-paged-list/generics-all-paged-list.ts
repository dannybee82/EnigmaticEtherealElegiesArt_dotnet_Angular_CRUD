import { computed, inject, Injectable, resource, ResourceRef, ResourceStatus, signal, Signal, WritableSignal } from "@angular/core";
import { environment } from "../../../../../environments/environment";
import { GenericsShared } from "../shared/generics-shared.interface";
import { RESOURCE_CONFIG } from "../tokens/resource.config";
import { GenericsAllPagedListInterface } from "./generics-all-paged-list.interface";
import { SharedParams } from "../shared/shared-params.abstract";
import { PaginatedList } from "../../../models/paginated-list/paginated-list.interface";

@Injectable({
  providedIn: 'root'
})  
export class GenericsAllPagedListService<T> extends SharedParams implements GenericsAllPagedListInterface<T>, GenericsShared {
  
    private readonly config = inject(RESOURCE_CONFIG);  
    private readonly api = environment.apiUrl;  
    readonly params: WritableSignal<Map<string, any> | undefined> = signal<Map<string, any> | undefined>(undefined);
    
    private readonly resource: ResourceRef<PaginatedList<T> | undefined> = resource<PaginatedList<T> | undefined, unknown>({  
        defaultValue: undefined,
        loader: async ({ abortSignal }) => { 
            if(this.config.methodGetAllPagedList?.controller && this.config.methodGetAllPagedList?.method && this.params()) {
                const res = await fetch(  
                    `${this.api}/${this.config.methodGetAllPagedList.controller}/${this.config.methodGetAllPagedList.method}${this.buildParams(this.params()!)}`,  
                    { signal: abortSignal, headers: { 'Content-Type': 'application/json' } }  
                );
            
                if (!res.ok) throw new Error(`HTTP ${res.status}`);  
                return res.json() as Promise<PaginatedList<T>>;
            }               

            return undefined;  
        }  
    });  
      
    readonly data: WritableSignal<PaginatedList<T> | undefined> = this.resource.value;  
    readonly isLoading: Signal<boolean> = this.resource.isLoading;  
    readonly error: Signal<Error | undefined>   = this.resource.error;  
    readonly hasValue: Signal<boolean> = computed(() => this.resource.hasValue());  
    readonly status: Signal<ResourceStatus> = this.resource.status;

    reload(): void 
    { 
        this.resource.reload(); 
    }  

    destroy(): void { 
        this.resource.destroy(); 
    }  
}