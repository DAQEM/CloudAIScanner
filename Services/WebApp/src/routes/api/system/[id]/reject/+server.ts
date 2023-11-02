import { systems, type System } from '$lib/api/systems';
import type { RequestHandler } from './$types';

export const GET: RequestHandler = async ({params}) => {
    const system: System | undefined = systems.find((system) => system.id === params.id);

    if (!system) {
        return new Response(
            JSON.stringify({error: 'Invalid ID'}),
            {
                headers: {
                    'content-type': 'application/json'
                }
            }
        );
    }

    system.status = 'Rejected';

    return new Response(JSON.stringify(system), {
        headers: {
            'content-type': 'application/json'
        }
    });
};