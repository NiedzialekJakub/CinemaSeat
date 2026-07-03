import { useQuery } from "@tanstack/react-query"
import agent from "../api/agent"

export const useFilms = (id?: number) => {
    const {data: films, isPending} = useQuery({
        queryKey: ['films'],
        queryFn: async () => {
            const response = await agent.get<Film[]>('/films')
            return response.data;
        }
    })

    const {data: film, isLoading} = useQuery({
        queryKey: ['films', id],
        queryFn: async () => {
            const response = await agent.get<Film>(`/films/${id}`);
            return response.data;
        },
        enabled: !!id // sprawdzam czy wgl id jest bo jak nie klikne przycisku buy ticket no to nie bedzie id a ten hook sie wykona nawet jak nie ma id i beda errory
    })

    return{
        films,
        isPending,
        film,
        isLoading
    }
}