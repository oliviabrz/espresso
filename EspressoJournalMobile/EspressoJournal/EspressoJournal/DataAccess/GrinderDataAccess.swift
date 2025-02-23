import Foundation

class GrinderDataAccess {
    
    func GetGrinder(completion: @escaping (Result<GrinderDto, Error>) -> Void) {
        // Build API request
        guard let url = URL(string: "http://localhost:5100/grinder/9") else {
            completion(.failure(URLError(.badURL)))
            return
        }
        
        // Make API Call
        URLSession.shared.dataTask(with: url) { data, response, error in
            
            // Check errors
            guard let data = data, error == nil else {
                completion(.failure(error ?? URLError(.badServerResponse)))
                return
            }
            
            // Parse response
            let decoder = JSONDecoder()
            let grinderDto = try? decoder.decode(GrinderDto.self, from: data)
            
            // Complete callback
            if let grinderDto = grinderDto {
                completion(.success(grinderDto))
            } else {
                completion(.failure(URLError(.cannotParseResponse)))
            }
            
        }.resume()  // Fire off task
    }
}
