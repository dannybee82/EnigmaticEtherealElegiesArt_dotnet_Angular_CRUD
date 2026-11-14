import {  computed, inject, Injectable, resource, ResourceRef, ResourceStatus,  Signal, signal, WritableSignal } from '@angular/core';  
import { environment } from '../../../../../environments/environment';  
import { RESOURCE_CONFIG, ResourceConfig } from '../tokens/resource.config';
import { GenericsByParamsInterface } from './generics-by-params.interface';
import { GenericsShared } from '../shared/generics-shared.interface';
import { SharedParams } from '../shared/shared-params.abstract';
  
@Injectable({
  providedIn: 'root'
})  
export class GenericsByParamsService<T, U> extends SharedParams implements GenericsByParamsInterface<T>, GenericsShared {
 
  private readonly config: ResourceConfig = inject(RESOURCE_CONFIG);  
  private readonly api = environment.apiUrl;
  
  readonly params: WritableSignal<U | undefined> = signal(undefined);
  readonly additionalParams: WritableSignal<Map<string, any> | undefined> = signal<Map<string, any> | undefined>(undefined);
  
  private readonly resource: ResourceRef<T[] | undefined> = resource<T[] | undefined, unknown>({  
    params: () => this.params(),
    loader: async ({ abortSignal }) => { 
      if(this.params()) {
        const url = 
          `${this.api}/${this.config.methodByParams?.controller}/${this.config.methodByParams?.method}${this.buildQueryAndParams(this.params()!, this.additionalParams())}`;  
  
        const response = await fetch(url, {  
          signal: abortSignal,  
          headers: { 'Content-Type': 'application/json' }  
        });  
        
        if (!response.ok) throw new Error(`HTTP ${response.status}: ${response.statusText}`);  
        return response.json() as Promise<T[]>;  
      }
      
      return undefined;
    }  
  });  

  readonly data: Signal<T[] | undefined> = this.resource.value;  
  readonly isLoading: Signal<boolean> = this.resource.isLoading;  
  readonly error: Signal<Error | undefined> = this.resource.error;  
  readonly status: Signal<ResourceStatus> = this.resource.status;  
  readonly hasValue: Signal<boolean> = computed(() => this.resource.hasValue()); 
  
  reload(): void 
  { 
    this.resource.reload(); 
  }  

  destroy(): void { 
    this.resource.destroy(); 
  }  
  
}