import { useEffect, useState } from 'react';
import { Box, Button, Spinner, Table, Tbody, Td, Th, Thead, Tr, Text } from '@chakra-ui/react';
import { API_ENDPOINTS } from '@/config/api';


const Scoreboard = () => {
  const [players, setPlayers] = useState<Player[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [loadingReset, setLoadingReset] = useState(false);
  const [resetError, setResetError] = useState<string | null>(null);

  useEffect(() => {
    const fetchScoreboard = async () => {
      try {
        const response = await fetch(API_ENDPOINTS.SCOREBOARD);
        if (!response.ok) {
          throw new Error('Failed to fetch scoreboard data');
        }
        const data: Player[] = await response.json();
        setPlayers(data);
      } catch (error: any) {
        setError(error.message);
      } finally {
        setLoading(false);
      }
    };

    fetchScoreboard();
  }, []);

  const resetScoreboard = async () => {
    setLoadingReset(true);
    setResetError(null);

    try {
      const response = await fetch(API_ENDPOINTS.RESET_SCOREBOARD, {
        method: 'DELETE',
        headers: {
          'Content-Type': 'application/json',
        },
      });
      if (!response.ok) {
        throw new Error('Failed to reset scoreboard');
      }
      setPlayers([]);
    } catch (error: any) {
      setResetError(error.message);
    } finally {
      setLoadingReset(false);
    }
  };

  if (loading) {
    return <Spinner />;
  }

  if (error) {
    return <Text color="red.500">Error: {error}</Text>;
  }

  return (
    <Box>
      <Table variant="simple">
        <Thead>
          <Tr>
            <Th>Player ID</Th>
            <Th>Win Streak</Th>
            <Th>Total Wins</Th>
            <Th>Total Losses</Th>
            <Th>Total Ties</Th>
            <Th>Last Game Result</Th>
            <Th>Last Played At</Th>
          </Tr>
        </Thead>
        <Tbody>
          {players.map((player) => (
            <Tr key={player.playerId}>
              <Td>{player.playerId}</Td>
              <Td>{player.winStreak}</Td>
              <Td>{player.totalWins}</Td>
              <Td>{player.totalLosses}</Td>
              <Td>{player.totalTies}</Td>
              <Td>{player.lastGameResult}</Td>
              <Td>{new Date(player.lastPlayedAt).toLocaleString()}</Td>
            </Tr>
          ))}
        </Tbody>
      </Table>

      <Button onClick={resetScoreboard} mt={4} colorScheme="red" isLoading={loadingReset}>
        Reset Scoreboard
      </Button>

      {resetError && <Text color="red.500" mt={2}>Error: {resetError}</Text>}
    </Box>
  );
};

export default Scoreboard;
