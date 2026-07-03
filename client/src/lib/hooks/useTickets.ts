import { useQuery } from "@tanstack/react-query"
import agent from "../api/agent"

export const useTickets = (id: number | undefined) => {
    const {data: tickets, isPending} = useQuery({
        queryKey: ['tickets'],
        queryFn: async () => {
            const response = await agent.get<Ticket[]>(`/tickets/film/${id}`);
            return response.data;
        },
        enabled: !!id
    })


    return{
        tickets,
        isPending
    }
}