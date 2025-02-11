import { useState, useEffect, useRef } from 'react';
import useSWR from 'swr';
import { API_ENDPOINTS } from '@/config/api';
import { fetcher, postRequest } from '@/utils/api';

interface Choice {
  id: number;
  name: string;
}

interface PlayResponse {
  results: 'win' | 'lose' | 'tie';
  player: number;
  computer: number;
}

const useGame = () => {
  const { data: choices, error: choicesError } = useSWR<Choice[]>(API_ENDPOINTS.CHOICES, fetcher);
  const [result, setResult] = useState<{ results: string; player: string; computer: string } | null>(null);
  const [loadingPlay, setLoadingPlay] = useState(false);
  const [playError, setPlayError] = useState<string | null>(null);
  const playerIdRef = useRef<number>(Math.floor(Math.random() * 10) + 1);

  const handleChoiceClick = async (player: number) => {
    setLoadingPlay(true);
    setPlayError(null);
    setResult(null);

    try {
      const data: PlayResponse = await postRequest(API_ENDPOINTS.PLAY, { player, playerId: playerIdRef.current });

      const playerChoice = choices?.find(choice => choice.id === data.player)?.name || 'Unknown';
      const computerChoice = choices?.find(choice => choice.id === data.computer)?.name || 'Unknown';

      setResult({ results: data.results, player: playerChoice, computer: computerChoice });
    } catch (error: any) {
      setPlayError(error.message);
    } finally {
      setLoadingPlay(false);
    }
  };

  return {
    choices,
    choicesError,
    result,
    loadingPlay,
    playError,
    handleChoiceClick,
    playerId: playerIdRef.current,
  };
};

export default useGame;
