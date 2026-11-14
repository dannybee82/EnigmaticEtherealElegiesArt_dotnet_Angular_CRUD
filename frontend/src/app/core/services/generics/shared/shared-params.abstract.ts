export abstract class SharedParams {
    buildParams(params: Map<string, unknown>): string {
        let p: string = '';

        if(params) {
            for (const [key, value] of Array.from(params)) {
                p = p === '' ? 
                    p += '?' + key + '=' + String(value) : 
                    p += '&' + key + '=' + String(value);
            }
        }

        return p;
    }

    buildQuery(queryParams: Record<string, unknown>): URLSearchParams {
        const query = new URLSearchParams(  
            Object.entries(queryParams).map(([k, v]) => [k, String(v)])  
        ); 

        return query;
    }

    buildQueryAndParams(queryParams: Record<string, unknown>, params?: Map<string, any>): string {
        const query = new URLSearchParams(  
            Object.entries(queryParams).map(([k, v]) => [k, String(v)])  
        ); 

        if(params) {
            let p: string = '';
      
            for (const [key, value] of Object.entries(params)) {
                p += '&' + key + '=' + value;
            }

            return `${query}${p}`;
        }

        return `${query}`;
    }
}